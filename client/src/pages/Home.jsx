import { Box, Container, Stack, Typography } from "@mui/material";

import Wave from "../components/Wave";
import HeroMap from "../components/Home/HeroMap";
import Mission from "../components/Home/Mission";
import Steps from "../components/Home/Steps";

const Home = () => {
  return (
    <div>
      <HeroMap />
      <Wave from="brand.soft" to="background.default" flip />
      <Mission />
      <Wave from="background.default" to="brand.ink" />
      <Steps />
    </div>
  );
};

export default Home;
