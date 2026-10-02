import { Navigate, Route, Routes } from "react-router";
import { allPages } from "./pages/pages";
import MainLayout from "./pages/layouts/MainLayout";
import RoleGuard from "./pages/layouts/RoleGuard";

const App = () => {
    return (
        <Routes>
            <Route element={<MainLayout />}>
                {allPages.map(({ id, path, component: Page, roles }) => (
                    <Route
                        key={id}
                        path={path}
                        element={
                            <RoleGuard roles={roles}>
                                <Page />
                            </RoleGuard>
                        }
                    />
                ))}
                <Route path="*" element={<Navigate to="/" replace />} />
            </Route>
        </Routes>
    );
};

export default App;
