
import { Link } from "react-router";
import { Box, Stack, Typography } from "@mui/material";

const Logo = () => {
    return (
        <Stack direction="row" spacing={1} component={Link} to="/" sx={{ alignItems: "center", color: "text.primary", textDecoration: "none" }}>
            <Box component="img" src="/logo_2.png" alt="" sx={{ height: 36 }} />
            <Typography variant="h5" component="span">
                Mancs<Box component="span" sx={{ color: "primary.main" }}>Radar</Box>
            </Typography>
        </Stack>
    );
};

export default Logo;