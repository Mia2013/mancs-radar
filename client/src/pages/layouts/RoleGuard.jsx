import { Navigate } from "react-router";
import { useAuth } from "../../provider/AuthProvider";

const RoleGuard = ({ roles, children }) => {
    const { user } = useAuth();

    if (roles.includes(user.role)) {
        return children;
    }

    return <Navigate to="/" replace />;
};

export default RoleGuard;
