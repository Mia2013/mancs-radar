import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter } from "react-router";
import { CssBaseline } from "@mui/material";
import { ThemeProvider } from "@mui/material/styles";
import theme from "./theme";
import AuthProvider from "./provider/AuthProvider";
import App from "./App";
import "./index.scss";

createRoot(document.getElementById("root")).render(
    <StrictMode>
        <BrowserRouter>
            <ThemeProvider theme={theme} defaultMode="light">
                <CssBaseline />
                <AuthProvider>
                    <App />
                </AuthProvider>
            </ThemeProvider>
        </BrowserRouter>
    </StrictMode>
);
