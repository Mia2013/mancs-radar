import { Link } from "react-router";
import { Box, Button, Container, Stack, Typography } from "@mui/material";
import CampaignIcon from "@mui/icons-material/Campaign";

const CallToAction = () => {
    return (
        <Box component="section" sx={{ bgcolor: "primary.main", color: "primary.contrastText", py: { xs: 4, md: 6 } }}>
            <Container maxWidth="lg">
                <Stack direction={{ xs: "column", md: "row" }} spacing={3} sx={{ justifyContent: "space-between", alignItems: { md: "center" } }}>
                    <Box>
                        <Typography variant="h3">Elvesztett vagy talált egy kutyát?</Typography>
                        <Typography>Jelentsd be most, mert minden perc számít!</Typography>
                    </Box>
                    <Stack direction={{ xs: "column", sm: "row" }} spacing={1.5}>
                        <Button variant="contained" color="secondary" size="large" startIcon={<CampaignIcon />} component={Link} to="/report">Bejelentés indítása</Button>
                        <Button variant="outlined" color="inherit" size="large" component={Link} to="/register">Regisztráció</Button>
                    </Stack>
                </Stack>
            </Container>
        </Box>
    );
};

export default CallToAction;