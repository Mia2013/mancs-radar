import { useEffect, useState } from "react";
import {
  Avatar,
  Backdrop,
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  CardHeader,
  Chip,
  Container,
  Grow,
  Paper,
  Slide,
  Stack,
  Typography,
  useMediaQuery,
} from "@mui/material";
import { keyframes } from "@mui/material/styles";
import CheckIcon from "@mui/icons-material/Check";
import CircleIcon from "@mui/icons-material/Circle";
import LocationOnIcon from "@mui/icons-material/LocationOn";
import PhotoCameraOutlinedIcon from "@mui/icons-material/PhotoCameraOutlined";
import dayjs from "dayjs";
import "dayjs/locale/hu";

import BudapestMap from "./BudapestMap";
import MapPin from "./MapPin";

const buzz = keyframes`
    0%, 100% { transform: translateX(0) rotate(0); }
    20%, 60% { transform: translateX(-5px) rotate(-2deg); }
    40%, 80% { transform: translateX(5px) rotate(2deg); }
`;

const VIEWBOX = {
  desktop: { x: 0, y: 0, w: 1312, h: 680 },
  mobile: { x: 380, y: 0, w: 420, h: 680 },
};

const TIMING = { cards: 2000, match: 5000, phone: 5400, buzz: 6300 };

const LINE = { begin: 2600, duration: 2400 };

const DIM_AT = 2100;

const ROLE_COLORS = { seeker: "seeker.main", finder: "primary.main" };

const MAIN = {
  seeker: { x: 430, y: 150, delay: 300 },
  finder: { x: 740, y: 520, delay: 1100 },
};

const DECOR_PINS = [
  { x: 753, y: 176, role: "finder", delay: 600 },
  { x: 960, y: 190, role: "seeker", delay: 700 },
  { x: 636, y: 280, role: "seeker", delay: 900 },
  { x: 190, y: 420, role: "seeker", delay: 1000 },
  { x: 448, y: 446, role: "finder", delay: 1300 },
  { x: 300, y: 560, role: "finder", delay: 1400 },
  { x: 767, y: 610, role: "seeker", delay: 1500 },
];

const PINGS = [
  { ...MAIN.finder, color: "primary.main", delay: 2200 },
  { ...MAIN.seeker, color: "success.main", delay: 5000 },
];

const ROUTE =
  "M 740 518 C 700 470, 616 344, 588 322 C 560 300, 500 150, 430 148";

const LABELS = { buda: { x: 398, y: 262 }, pest: { x: 690, y: 250 } };

const MATCH = { x: 401, y: 162 };

const DOG_CARDS = [
  {
    status: "Elveszett",
    name: "Bogyó",
    place: "II. kerület · gazdi fotója",
    color: "seeker",
    outlined: false,
    x: 464,
    y: 19,
  },
  {
    status: "Talált",
    name: "Ismeretlen kutya",
    place: "VIII. kerület · megtaláló fotója",
    color: "primary",
    outlined: true,
    x: 420,
    y: 490,
  },
];

const HeroMap = () => {
  const isMobile = useMediaQuery((theme) => theme.breakpoints.down("md"), {
    noSsr: true,
  });
  const viewBox = isMobile ? VIEWBOX.mobile : VIEWBOX.desktop;
  const [mapElement, setMapElement] = useState(null);
  const [reached, setReached] = useState({});
  const today = dayjs().locale("hu").format("YYYY. MMMM D., dddd");

  useEffect(() => {
    const timers = Object.entries(TIMING).map(([key, ms]) =>
      setTimeout(() => setReached((prev) => ({ ...prev, [key]: true })), ms),
    );
    return () => timers.forEach(clearTimeout);
  }, []);

  const place = ({ x, y }) => ({
    position: "absolute",
    left: `${((x - viewBox.x) / viewBox.w) * 100}%`,
    top: `${((y - viewBox.y) / viewBox.h) * 100}%`,
  });

  return (
    <Box
      component="section"
      sx={{ bgcolor: "brand.soft", pb: { xs: 4, md: 8 }, pt: 3 }}
    >
      <Container maxWidth="lg">
        <Paper
          ref={setMapElement}
          className="dark"
          elevation={12}
          sx={{
            position: "relative",
            overflow: "hidden",
            bgcolor: "background.default",
            aspectRatio: `${viewBox.w} / ${viewBox.h}`,
          }}
        >
          <Box
            component="svg"
            viewBox={`${viewBox.x} ${viewBox.y} ${viewBox.w} ${viewBox.h}`}
            sx={{
              display: "block",
              width: "100%",
              height: "100%",
              color: reached.match ? "success.main" : "primary.main",
              transition: "color .6s",
            }}
          >
            <BudapestMap labels={LABELS} />

            {PINGS.map((ping) => (
              <Box component="g" key={ping.delay} sx={{ color: ping.color }}>
                <circle
                  cx={ping.x}
                  cy={ping.y}
                  r="0"
                  fill="none"
                  stroke="currentColor"
                  strokeWidth="2"
                  opacity="0"
                >
                  <animate
                    attributeName="r"
                    from="12"
                    to="120"
                    dur="1.4s"
                    begin={`${ping.delay}ms`}
                    fill="freeze"
                  />
                  <animate
                    attributeName="opacity"
                    values="0;1;0"
                    keyTimes="0;0.2;1"
                    dur="1.4s"
                    begin={`${ping.delay}ms`}
                    fill="freeze"
                  />
                </circle>
              </Box>
            ))}

            <mask
              id="route-mask"
              maskUnits="userSpaceOnUse"
              x="0"
              y="0"
              width="1312"
              height="680"
            >
              <path
                d={ROUTE}
                stroke="#fff"
                strokeWidth="14"
                fill="none"
                strokeLinecap="round"
                pathLength="1000"
                strokeDasharray="1000"
                strokeDashoffset="1000"
              >
                <animate
                  attributeName="stroke-dashoffset"
                  from="1000"
                  to="0"
                  dur={`${LINE.duration}ms`}
                  begin={`${LINE.begin}ms`}
                  fill="freeze"
                />
              </path>
            </mask>
            <path
              d={ROUTE}
              stroke="currentColor"
              strokeWidth="4"
              strokeDasharray="10 11"
              strokeLinecap="round"
              fill="none"
              mask="url(#route-mask)"
            />
            <circle r="7" fill="currentColor" opacity="0">
              <animateMotion
                path={ROUTE}
                dur={`${LINE.duration}ms`}
                begin={`${LINE.begin}ms`}
                fill="freeze"
              />
              <animate
                attributeName="opacity"
                values="1;1;0"
                keyTimes="0;0.9;1"
                dur={`${LINE.duration}ms`}
                begin={`${LINE.begin}ms`}
                fill="freeze"
              />
            </circle>

            {DECOR_PINS.map((pin) => (
              <MapPin
                key={`${pin.x}-${pin.y}`}
                {...pin}
                size={36}
                dimAt={DIM_AT}
                color={ROLE_COLORS[pin.role]}
              />
            ))}
            {Object.entries(MAIN).map(([role, pin]) => (
              <MapPin
                key={role}
                {...pin}
                size={48}
                color={reached.match ? "success.main" : ROLE_COLORS[role]}
              />
            ))}
          </Box>

          {DOG_CARDS.map((dog, index) => (
            <Grow
              key={dog.name}
              in={!!reached.cards}
              style={{ transitionDelay: `${index * 300}ms` }}
            >
              <Card sx={place(dog)}>
                <CardHeader
                  avatar={
                    <Avatar
                      variant="rounded"
                      sx={{
                        width: { xs: 48, md: 64 },
                        height: { xs: 48, md: 64 },
                      }}
                    >
                      <PhotoCameraOutlinedIcon />
                    </Avatar>
                  }
                  title={
                    <Stack spacing={0.5} sx={{ alignItems: "flex-start" }}>
                      <Chip
                        label={dog.status}
                        color={dog.color}
                        size="small"
                        variant={dog.outlined ? "outlined" : "filled"}
                      />
                      <Typography variant="h6">{dog.name}</Typography>
                    </Stack>
                  }
                  subheader={dog.place}
                />
              </Card>
            </Grow>
          ))}

          <Grow in={!!reached.match}>
            <Chip
              icon={<CheckIcon />}
              label="Egyezés!"
              color="success"
              sx={place(MATCH)}
            />
          </Grow>

          <Stack
            direction="row"
            spacing={1}
            sx={{ position: "absolute", left: 16, bottom: 16 }}
          >
            <Chip size="small" icon={<LocationOnIcon />} label="Budapest" />
            <Chip
              size="small"
              icon={<CircleIcon />}
              label="Elveszett"
              sx={{ "& .MuiChip-icon": { color: "seeker.main" } }}
            />
            <Chip
              size="small"
              icon={<CircleIcon />}
              label="Talált"
              sx={{ "& .MuiChip-icon": { color: "primary.main" } }}
            />
          </Stack>

          <Backdrop
            open={!!reached.phone}
            sx={{ position: "absolute", zIndex: 1 }}
          />

          <Box
            sx={{
              position: "absolute",
              zIndex: 2,
              top: "50%",
              left: { xs: "50%", md: "auto" },
              right: { md: "3%" },
              transform: {
                xs: "translate(-50%, -50%)",
                md: "translateY(-50%)",
              },
            }}
          >
            <Box sx={{ animation: reached.buzz ? `${buzz} .75s` : "none" }}>
              <Slide in={!!reached.phone} direction="up" container={mapElement}>
                <Paper
                  elevation={24}
                  sx={{
                    width: { xs: 210, md: 230 },
                    p: 1.5,
                    borderRadius: 2.5,
                    border: 6,
                    borderColor: "grey.800",
                    bgcolor: "common.black",
                  }}
                >
                  <Stack spacing={1}>
                    <Stack sx={{ alignItems: "center", pt: 1 }}>
                      <Typography variant="h4" component="p">
                        14:32
                      </Typography>
                      <Typography
                        variant="caption"
                        sx={{ color: "text.secondary" }}
                      >
                        {today}
                      </Typography>
                    </Stack>
                    <Card variant="outlined">
                      <CardHeader
                      sx={{pb: 1}}
                        avatar={
                          <Avatar
                            src="/logo_2.png"
                            variant="rounded"
                            sx={{
                              width: 40,
                              height: 40,
                              bgcolor: "transparent",
                              "& img": { objectFit: "contain" },
                            }}
                          />
                        }
                        title="MancsRadar"
                        subheader="most"
                      />
                      <CardContent>
                        <Typography
                          variant="subtitle1"
                          color="primary"
                          sx={{ fontWeight: 700 }}
                        >
                          Lehetséges egyezés!
                        </Typography>
                        <Typography
                          variant="body2"
                          sx={{ color: "text.secondary" }}
                        >
                          Egy talált kutya nagyon hasonlít Bogyóra, a VIII.
                          kerületben.
                        </Typography>
                      </CardContent>
                      <CardActions>
                        <Button variant="contained" fullWidth>
                          Megnézem
                        </Button>
                      </CardActions>
                    </Card>
                  </Stack>
                </Paper>
              </Slide>
            </Box>
          </Box>
        </Paper>
      </Container>
    </Box>
  );
};

export default HeroMap;
