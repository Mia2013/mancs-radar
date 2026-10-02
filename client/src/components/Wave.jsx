import { Box } from "@mui/material";

const Wave = ({ from, to, flip = false }) => {
    return (
        <Box component="svg" viewBox="0 0 1440 80" preserveAspectRatio="none" sx={{ display: "block", position: "relative", zIndex: 1, overflow: "visible", width: "100%", height: { xs: 32, md: 64 }, transform: flip ? "scaleX(-1)" : "none" }}>
            <Box component="rect" x="0" y="-4" width="1440" height="84" fill="currentColor" sx={{ color: from }} />
            <Box component="path" d="M0 84 L0 40 C 180 0, 360 0, 540 30 S 900 80, 1080 44 S 1340 0, 1440 24 L1440 84 Z" fill="currentColor" sx={{ color: to }} />
        </Box>
    );
};

export default Wave;
