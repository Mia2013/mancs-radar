import { useState } from "react";
import { Link, NavLink } from "react-router";
import { AppBar, Button, Container, Drawer, IconButton, List, ListItemButton, ListItemText, Stack, Toolbar } from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import { allPages } from "../pages/pages";
import { useAuth } from "../provider/AuthProvider";
import Logo from "./Logo";

const Navigation = () => {
    const { user, isAuthenticated, logOut } = useAuth();
    const [open, setOpen] = useState(false);

    const visiblePages = allPages.filter((page) => page.showInNavbar && page.roles.includes(user.role));

    return (
        <AppBar position="sticky" color="inherit" elevation={0}>
            <Container maxWidth="lg">
                <Toolbar disableGutters sx={{ gap: 2 }}>
                    <Logo />
                    <Stack direction="row" spacing={1} sx={{ justifyContent: "center", flexGrow: 1, display: { xs: "none", md: "flex" } }}>
                        {visiblePages.map((page) => (
                            <Button key={page.id} component={NavLink} to={page.path} end={page.path === "/"} color="inherit" sx={{ "&.active": { color: "primary.dark" } }}>
                                {page.name}
                            </Button>
                        ))}
                    </Stack>
                    <Stack direction="row" spacing={1} sx={{ display: { xs: "none", md: "flex" } }}>
                        {isAuthenticated && <Button variant="outlined" color="inherit" onClick={logOut}>Kilépés</Button>}
                        <Button variant="contained" component={Link} to="/report">Kutyát jelentek</Button>
                    </Stack>
                    <IconButton aria-label="Menü" onClick={() => setOpen(true)} sx={{ ml: "auto", display: { md: "none" } }}>
                        <MenuIcon />
                    </IconButton>
                </Toolbar>
            </Container>
            <Drawer anchor="right" open={open} onClose={() => setOpen(false)}>
                <List sx={{ width: 260 }}>
                    {visiblePages.map((page) => (
                        <ListItemButton key={page.id} component={NavLink} to={page.path} onClick={() => setOpen(false)}>
                            <ListItemText primary={page.name} />
                        </ListItemButton>
                    ))}
                    {isAuthenticated && (
                        <ListItemButton onClick={logOut}>
                            <ListItemText primary="Kilépés" />
                        </ListItemButton>
                    )}
                </List>
            </Drawer>
        </AppBar>
    );
};

export default Navigation;