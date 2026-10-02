import { Outlet } from "react-router";
import { Box } from "@mui/material";
import Navigation from "../../components/Nav";
import Footer from "../../components/Footer";

const MainLayout = () => {
    return (
        <>
            <Navigation />
            <Box component="main">
                <Outlet />
            </Box>
            <Footer />
        </>
    );
};

export default MainLayout;
