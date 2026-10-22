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
import PetsIcon from "@mui/icons-material/Pets";

import { useAuth } from "../provider/AuthProvider";
import ValidationCaption from "./ValidationCaption";

const RegisterForm = () => {
  const { register } = useAuth();

  const [showPassword, setShowPassword] = useState(false);
  const [validationErrors, setValidationErrors] = useState({});

  const emailRef = useRef();
  const passwordRef = useRef();
  const confirmPasswordRef = useRef();
  const phoneNumberRef = useRef();

  const handleToggleShowPassword = () => setShowPassword((show) => !show);

  const validateForm = (data, confirmPassword) => {
    const errors = {};

    if (!data.email) {
      errors.email = "Az email cím megadása kötelező!";
    }

    if (!data.password.trim()) {
      errors.password = "A jelszó megadása kötelező!";
    }

    if (data.password !== confirmPassword) {
      errors.confirmPassword = "A jelszavak nem egyeznek!";
    }

    return errors;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const formData = {
      email: emailRef.current.value.trim(),
      password: passwordRef.current.value,
      phoneNumber: phoneNumberRef.current.value.trim() || null,
    };

    const errors = validateForm(formData, confirmPasswordRef.current.value);
    if (Object.keys(errors).length > 0) {
      setValidationErrors(errors);
      return;
    }
    setValidationErrors({});
    await register(formData);
  };

  return (
    <Box component="section" sx={{ py: { xs: 4, md: 8 } }}>
      <Container maxWidth="sm">
        <Paper elevation={6} sx={{ p: { xs: 3, md: 5 } }}>
          <Stack
            spacing={1.5}
            sx={{ alignItems: "center", textAlign: "center", mb: 4 }}
          >
            <Chip
              label="REGISZTRÁCIÓ"
              color="secondary"
              sx={{ fontWeight: "bold", py: 2, px: 4, fontSize: "1.25rem" }}
            />
            <Typography sx={{ color: "text.secondary" }}>
              Hozd létre a fiókodat, hogy elveszett vagy talált kutyát
              jelenthess be.
            </Typography>
          </Stack>

          <Box
            component="form"
            noValidate
            onSubmit={handleSubmit}
            sx={{ display: "flex", flexDirection: "column", gap: 2 }}
          >
            <Stack direction={{ xs: "column", sm: "row" }} spacing={2}>
              <TextField
                fullWidth
                label="Email cím*"
                type="email"
                inputRef={emailRef}
                error={!!validationErrors.email}
                helperText={validationErrors.email}
                icon={<InputAdornment position="start">@</InputAdornment>}
              />
              <TextField
                fullWidth
                label="Telefonszám"
                type="tel"
                inputRef={phoneNumberRef}
              />
            </Stack>

            <Stack direction={{ xs: "column", sm: "row" }} spacing={2}>
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
                      <IconButton onClick={handleToggleShowPassword} edge="end">
                        {showPassword ? <VisibilityOff /> : <Visibility />}
                      </IconButton>
                    </InputAdornment>
                  }
                />
                {validationErrors.password && (
                  <ValidationCaption message={validationErrors.password} />
                )}
              </FormControl>

              <FormControl
                variant="outlined"
                fullWidth
                error={!!validationErrors.confirmPassword}
              >
                <InputLabel>Jelszó újra*</InputLabel>
                <OutlinedInput
                  inputRef={confirmPasswordRef}
                  type={showPassword ? "text" : "password"}
                  label="Jelszó újra*"
                  endAdornment={
                    <InputAdornment position="end">
                      <IconButton onClick={handleToggleShowPassword} edge="end">
                        {showPassword ? <VisibilityOff /> : <Visibility />}
                      </IconButton>
                    </InputAdornment>
                  }
                />
                {validationErrors.confirmPassword && (
                  <ValidationCaption
                    message={validationErrors.confirmPassword}
                  />
                )}
              </FormControl>
            </Stack>

            <Button
              type="submit"
              variant="contained"
              size="large"
              startIcon={<PetsIcon />}
              sx={{ py: 1.5, mt: 1 }}
            >
              Fiók létrehozása
            </Button>

            <Typography
              variant="body2"
              sx={{ textAlign: "center", color: "text.secondary" }}
            >
              Már van fiókod?{" "}
              <Box
                component={Link}
                to="/login"
                sx={{
                  color: "text.primary",
                  fontWeight: 700,
                  textDecorationColor: (theme) => theme.palette.primary.main,
                }}
              >
                Lépj be!
              </Box>
            </Typography>
          </Box>
        </Paper>
      </Container>
    </Box>
  );
};

export default RegisterForm;
