import { useContext, createContext, useState, useEffect, useMemo } from "react";
import { useNavigate } from "react-router";
import { jwtDecode } from "jwt-decode";
import { instance, postData, putData, endpoints } from "../API/apiCalls";
import { ROLES } from "../constants/constants";

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
    const [token, setToken] = useState(localStorage.getItem("mancsradar_token") || "");
    const [user, setUser] = useState({ role: ROLES.GUEST });
    const [alert, setAlert] = useState();
    const navigate = useNavigate();

    const { isAdmin, isShelter, isUser, isAuthenticated } = useMemo(() => ({
        isAdmin: user?.role === ROLES.ADMIN,
        isShelter: user?.role === ROLES.SHELTER,
        isUser: user?.role === ROLES.USER,
        isAuthenticated: !!token
    }), [user, token]);

    const decodeToken = (_token) => {
        try {
            const decoded = jwtDecode(_token);
            setUser(decoded);
            return decoded;
        } catch {
            logOut();
            setAlert({ message: "Érvénytelen munkamenet!", severity: "error" });
        }
    };

    const setupSession = (activeToken) => {
        setToken(activeToken);
        localStorage.setItem("mancsradar_token", activeToken);
        instance.defaults.headers.common["Authorization"] = `Bearer ${activeToken}`;
        decodeToken(activeToken);
    };

    const logIn = (username, password) => {
        postData(endpoints.loginUser, { username, password })
            .then(data => {
                setupSession(data.token);
                setAlert({ message: "Sikeres bejelentkezés!", severity: "success" });
            })
            .catch(error => setAlert({ message: error.message || "Hiba a bejelentkezés során!", severity: "error" }));
    };

    const register = (formData) => {
        postData(endpoints.registerUser, formData)
            .then(() => {
                setAlert({ message: "Sikeres regisztráció!", severity: "success" });
                navigate("/login");
            })
            .catch(e => setAlert({ message: e.message || "Hiba a regisztráció során!", severity: "error" }));
    };

    const updateUser = (formData) => {
        putData(`${endpoints.updateUser}/${user.id}`, formData)
            .then(updatedUser => {
                setUser(prev => ({ ...prev, ...updatedUser }));
                setAlert({ message: "Profil sikeresen frissítve!", severity: "success" });
            })
            .catch(error => setAlert({ message: error.message || "Hiba a frissítés során!", severity: "error" }));
    };

    const logOut = () => {
        setToken("");
        localStorage.removeItem("mancsradar_token");
        delete instance.defaults.headers.common["Authorization"];
        setAlert({ message: "Sikeres kijelentkezés!", severity: "info" });
        setUser({ role: ROLES.GUEST });
        navigate("/");
    };

    useEffect(() => {
        if (token) {
            setupSession(token);
        }
    }, []);

    return (
        <AuthContext.Provider value={{
            token, user,
            isAdmin, isShelter, isUser, isAuthenticated,
            logIn, logOut, register, updateUser,
            alert, setAlert
        }}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthProvider;
export const useAuth = () => useContext(AuthContext);
