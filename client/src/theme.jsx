import { createTheme, responsiveFontSizes, alpha } from "@mui/material/styles";

const brand = {
  yellow: "#FECA01",
  yellowLight: "#FFD84D",
  yellowDark: "#C99F00",
  yellowSoft: "#FFF7DC",
  pink: "#FF5FA2",
  green: "#34D27B",
  ink: "#151517",
  black: "#151515",
  blackLight: "#3A3A3E",
  white: "#FFFFFF",
};

const theme = responsiveFontSizes(createTheme({
  cssVariables: { colorSchemeSelector: "class" },
  colorSchemes: {
    light: {
      palette: {
        primary: {
          main: brand.yellow,
          light: brand.yellowLight,
          dark: brand.yellowDark,
          contrastText: brand.black,
        },
        secondary: {
          main: brand.black,
          light: brand.blackLight,
          dark: "#000000",
          contrastText: brand.yellow,
        },
        seeker: { main: brand.pink, contrastText: brand.black },
        success: { main: brand.green, contrastText: brand.black },
        background: {
          default: brand.white,
          paper: brand.white,
        },
        text: {
          primary: brand.black,
          secondary: "#4A4A4F",
        },
        divider: "rgba(21,21,21,0.12)",
        brand: { soft: brand.yellowSoft, ink: brand.ink },
      },
    },
    dark: {
      palette: {
        primary: {
          main: brand.yellow,
          light: brand.yellowLight,
          dark: brand.yellowDark,
          contrastText: brand.black,
        },
        secondary: {
          main: brand.white,
          light: brand.white,
          dark: "#D9D9D9",
          contrastText: brand.black,
        },
        seeker: { main: brand.pink, contrastText: brand.black },
        success: { main: brand.green, contrastText: brand.black },
        background: {
          default: "#141416",
          paper: "#1E1E21",
        },
        text: {
          primary: "#F5F5F2",
          secondary: "#A9A9AF",
        },
        divider: "rgba(245,245,242,0.12)",
        brand: { soft: alpha(brand.yellow, 0.14), ink: brand.ink },
      },
    },
  },
  typography: {
    fontFamily: "Figtree, sans-serif",
    h1: { fontFamily: "'Baloo 2', sans-serif", fontWeight: 700, fontSize: "3.75rem", lineHeight: 1.2 },
    h2: { fontFamily: "'Baloo 2', sans-serif", fontWeight: 700, fontSize: "2.75rem", lineHeight: 1.2 },
    h3: { fontFamily: "'Baloo 2', sans-serif", fontWeight: 700, fontSize: "2.25rem", lineHeight: 1.2 },
    h4: { fontFamily: "'Baloo 2', sans-serif", fontWeight: 700 },
    h5: { fontFamily: "'Baloo 2', sans-serif", fontWeight: 600 },
    h6: { fontFamily: "'Baloo 2', sans-serif", fontWeight: 600 },
    button: { textTransform: "none", fontWeight: 700 },
  },
  shape: { borderRadius: 16 },
  components: {
    MuiButton: {
      defaultProps: { disableElevation: true },
      styleOverrides: { root: { borderRadius: 999 } },
    },
  },
}));

export default theme;
