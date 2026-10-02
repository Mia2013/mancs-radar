import { ALL_ROLES, ROLES } from "../constants/constants.js";
import Home from "./Home";
import Map from "./Map";
import Report from "./Report";
import PetDetails from "./PetDetails";
import Login from "./Login";
import Register from "./Register";
import Profile from "./Profile";
import Admin from "./Admin";

export const allPages = [
    {
        id: "home",
        name: "Kezdőlap",
        path: "/",
        component: Home,
        showInNavbar: true,
        roles: ALL_ROLES,
    },
    {
        id: "map",
        name: "Térkép",
        path: "/map",
        component: Map,
        showInNavbar: true,
        roles: ALL_ROLES,
    },
    {
        id: "report",
        name: "Bejelentés",
        path: "/report",
        component: Report,
        showInNavbar: true,
        roles: [ROLES.USER, ROLES.SHELTER, ROLES.ADMIN],
    },
    {
        id: "pet-details",
        name: "Állat részletek",
        path: "/pet/:petId",
        component: PetDetails,
        showInNavbar: false,
        roles: ALL_ROLES,
    },
    {
        id: "login",
        name: "Belépés",
        path: "/login",
        component: Login,
        showInNavbar: true,
        roles: [ROLES.GUEST],
    },
    {
        id: "register",
        name: "Regisztráció",
        path: "/register",
        component: Register,
        showInNavbar: true,
        roles: [ROLES.GUEST],
    },
    {
        id: "profile",
        name: "Profil",
        path: "/profile",
        component: Profile,
        showInNavbar: true,
        roles: [ROLES.USER, ROLES.SHELTER],
    },
    {
        id: "admin",
        name: "Admin",
        path: "/admin",
        component: Admin,
        showInNavbar: true,
        roles: [ROLES.ADMIN],
    },
];
