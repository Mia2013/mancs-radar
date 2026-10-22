import { useRef, useState } from "react";
import { Link } from "react-router";
import {
  Box,
  Button,
  Chip,
  Container,
  FormControl,
  IconButton,
  InputAdornment,
  InputLabel,
  OutlinedInput,
  Paper,
  Stack,
  TextField,
  Typography,
} from "@mui/material";
import VisibilityOff from "@mui/icons-material/VisibilityOff";
import Visibility from "@mui/icons-material/Visibility";
import LoginIcon from "@mui/icons-material/Login";

import { useAuth } from "../provider/AuthProvider";
import ValidationCaption from "./ValidationCaption";

const EMAIL_REGEX = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

const LoginForm = () => {
  const { logIn } = useAuth();

  const [showPassword, setShowPassword] = useState(false);
  const [validationErrors, setValidationErrors] = useState({});

  const emailRef = useRef();
  const passwordRef = useRef();

  const handleClickShowPassword = () => setShowPassword((show) => !show);

  const validateForm = (data) => {
    const errors = {};

    if (!data.email) {
      errors.email = "Az email cím megadása kötelező!";
    } else if (!EMAIL_REGEX.test(data.email)) {
      errors.email = "Érvénytelen email cím!";
    }

    if (!data.password.trim()) {
      errors.password = "A jelszó megadása kötelező!";
    }

    return errors;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const formData = {
      email: emailRef.current.value.trim(),
      password: passwordRef.current.value,
    };

    const errors = validateForm(formData);
    if (Object.keys(errors).length > 0) {
      setValidationErrors(errors);
      return;
    }
    setValidationErrors({});
    await logIn(formData.email, formData.password);
  };

  return (
    <Box
      component="section"
      sx={{ bgcolor: "brand.soft", py: { xs: 4, md: 8 }, flexGrow: 1 }}
    >
      <Container maxWidth="xs">
        <Paper elevation={6} sx={{ p: { xs: 3, md: 5 } }}>
          <Stack
            spacing={1.5}
            sx={{ alignItems: "center", textAlign: "center", mb: 4 }}
          >
            <Chip
              label="BEJELENTKEZÉS"
              color="secondary"
              sx={{ fontWeight: "bold", py: 2, px: 4, fontSize: "1.25rem" }}
            />
            <Typography sx={{ color: "text.secondary" }}>
              Lépj be, hogy bejelentést tehess, vagy kövesd a kutyád keresését.
            </Typography>
          </Stack>

          <Box
            component="form"
            noValidate
            onSubmit={handleSubmit}
            sx={{ display: "flex", flexDirection: "column", gap: 2 }}
          >
            <TextField
              fullWidth
              label="Email cím*"
              type="email"
              inputRef={emailRef}
              error={!!validationErrors.email}
              helperText={validationErrors.email}
            />

            <FormControl
              variant="outlined"
              fullWidth
              error={!!validationErrors.password}
            >
              <InputLabel>Jelszó*</InputLabel>
              <OutlinedInput
                inputRef={passwordRef}
                type={showPassword ? "text" : "password"}
                label="Jelszó*"
                endAdornment={
                  <InputAdornment position="end">
                    <IconButton onClick={handleClickShowPassword} edge="end">
                      {showPassword ? <VisibilityOff /> : <Visibility />}
                    </IconButton>
                  </InputAdornment>
                }
              />
              {validationErrors.password && (
                <ValidationCaption message={validationErrors.password} />
              )}
            </FormControl>

            <Button
              type="submit"
              variant="contained"
              size="large"
              startIcon={<LoginIcon />}
              sx={{ py: 1.5, mt: 1 }}
            >
              Belépés
            </Button>

            <Typography
              variant="body2"
              sx={{ textAlign: "center", color: "text.secondary" }}
            >
              Még nincs fiókod?{" "}
              <Box
                component={Link}
                to="/register"
                sx={{
                  color: "text.primary",
                  fontWeight: 700,
                  textDecorationColor: (theme) => theme.palette.primary.main,
                }}
              >
                Regisztrálj!
              </Box>
            </Typography>
          </Box>
        </Paper>
      </Container>
    </Box>
  );
};

export default LoginForm;
