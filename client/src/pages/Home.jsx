import { Box, Container, Stack, Typography } from "@mui/material";

import Wave from "../components/Wave";
import HeroMap from "../components/Home/HeroMap";
import Mission from "../components/Home/Mission";
import Steps from "../components/Home/Steps";
import CallToAction from "../components/Home/CallToAction";

const Home = () => {
  return (
    <div>
      <HeroMap />
      <Wave from="brand.soft" to="background.default" flip />
      <Mission />
      <Wave from="background.default" to="brand.ink" />
      <Steps />
      <Wave from="brand.ink" to="primary.main" flip />
      <CallToAction />
    </div>
  );
};

export default Home;
