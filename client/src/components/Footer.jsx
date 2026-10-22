import { Box, Container, Stack, Typography } from "@mui/material";
import Logo from "./Logo";

const Footer = () => {
  return (
    <Box
      component="footer"
      className="dark"
      sx={{ bgcolor: "brand.ink", py: 2, borderTop: 1, borderColor: "divider" }}
    >
      <Container maxWidth="xl">
        <Stack
          direction={{ xs: "column", md: "row" }}
          spacing={2}
          sx={{ justifyContent: "space-between", alignItems: "center" }}
        >
          <Logo />
          <Typography variant="body2" sx={{ color: "text.secondary" }}>
            © {new Date().getFullYear()} MancsRadar by Budavári Nikolett -
            Minden jog fenntartva
          </Typography>
        </Stack>
      </Container>
    </Box>
  );
};

export default Footer;
