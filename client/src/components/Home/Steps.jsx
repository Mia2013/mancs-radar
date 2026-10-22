import {
  Avatar,
  Box,
  Container,
  Grid,
  Paper,
  Typography,
} from "@mui/material";

const Steps = () => {

  const STEPS = [
    { title: "Bejelentés", text: "Elveszett vagy talált kutyát jelentesz, fotóval és a helyszínnel a térképen." },
    { title: "Összevetés", text: "A platform a közelben bejelentett kutyák között keresi a hasonlókat." },
    { title: "Értesítés", text: "Ha egyezést találunk, azonnal szólunk, hogy a kutya hazajuthasson." },
];
  return (
    <Box
      component="section"
      id="hogyan-mukodik"
      className="dark"
      sx={{ bgcolor: "brand.ink", color: "text.primary", pt: 4, pb:8 }}
    >
      <Container maxWidth="lg">
        <Typography variant="h2" sx={{ mb: 4 }}>
          Hogyan{" "}
          <Box component="span" sx={{ color: "primary.main" }}>
            működik?
          </Box>
        </Typography>
        <Grid container spacing={3}>
          {STEPS.map((step, index) => (
            <Grid key={step.title} size={{ xs: 12, md: 4 }}>
              <Paper
                variant="outlined"
                sx={{
                  p: 3.5,
                  height: "100%",
                  display: "flex",
                  gap: 2,
                  "&:hover": { borderColor: "primary.main" },
                }}
              >
                <Avatar
                  sx={{
                    bgcolor: "primary.main",
                    color: "primary.contrastText",
                    fontWeight: 700,
                  }}
                >
                  {index + 1}
                </Avatar>
                <Box>
                  <Typography variant="h6">{step.title}</Typography>
                  <Typography variant="body2" sx={{ color: "text.secondary" }}>
                    {step.text}
                  </Typography>
                </Box>
              </Paper>
            </Grid>
          ))}
        </Grid>
      </Container>
    </Box>
  );
};

export default Steps;
