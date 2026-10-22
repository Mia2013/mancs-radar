import { Link } from "react-router";
import {
  Box,
  Button,
  Chip,
  Container,
  Grid,
  Stack,
  Typography,
} from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import PetsIcon from "@mui/icons-material/Pets";

const Mission = () => {
  return (
    <Box component="section" sx={{ py: { xs: 4, md: 8 } }}>
      <Container maxWidth="lg">
        <Grid
          container
          spacing={{ xs: 4, md: 8 }}
          sx={{ alignItems: "center" }}
        >
          <Grid size={{ xs: 12, md: 7 }} sx={{ order: { xs: 2, md: 1 } }}>
            <Stack spacing={3} sx={{ alignItems: "flex-start" }}>
              <Chip label="KÜLDETÉSÜNK" color="secondary" />
              <Typography variant="h1">
                Összekötjük az elveszett és talált{" "}
                <Box
                  component="mark"
                  sx={{
                    bgcolor: "primary.main",
                    color: "inherit",
                    px: 1,
                    borderRadius: 0.75,
                  }}
                >
                  kutyákat.
                </Box>
              </Typography>
              <Typography sx={{ color: "text.secondary" }}>
                Nem az a fontos, hogyan jutott ki - elszökött, megijedt, vagy
                eltévedt- , hanem az, hogy épségben hazataláljon.
              </Typography>
              <Typography sx={{ color: "text.secondary" }}>
                A villanyoszlopra ragasztott plakát elázik, a közösségi
                médiabejegyzés pedig percek alatt elsüllyed a hírfolyamban.
              </Typography>
              <Typography sx={{ color: "text.secondary" }}>
                A MancsRadar egyetlen közös, valós idejű térképen hozza össze a
                kétségbeesett gazdikat és a segíteni kész megtalálókat.
              </Typography>
              <Typography sx={{ color: "text.secondary" }}>
                Elég egy gyors fotó és a pontos helyszín: a platform összeveti
                az észleléseket az elveszett állatok adataival, lerövidítve a
                bizonytalanságban töltött napokat.
              </Typography>
              <Stack
                direction={{ xs: "column", sm: "row" }}
                spacing={1.5}
                sx={{ width: { xs: "100%", sm: "auto" } }}
              >
                <Button
                  variant="contained"
                  size="large"
                  startIcon={<SearchIcon />}
                  component={Link}
                  to="/"
                >
                  Elveszett a kutyám
                </Button>
                <Button
                  variant="outlined"
                  color="inherit"
                  size="large"
                  startIcon={<PetsIcon />}
                  component={Link}
                  to="/"
                >
                  Találtam egy kutyát
                </Button>
              </Stack>
            </Stack>
          </Grid>
          <Grid size={{ xs: 12, md: 5 }} sx={{ order: { xs: 1, md: 2 } }}>
            <Box
              component="img"
              src="/logo_1.png"
              alt="MancsRadar logó"
              sx={{
                width: "100%",
                maxWidth: { xs: 260, md: "none" },
                mx: "auto",
                display: "block",
              }}
            />
          </Grid>
        </Grid>
      </Container>
    </Box>
  );
};

export default Mission;
