import { useEffect, useRef, useState } from "react";
import {
  Autocomplete,
  Box,
  Button,
  Checkbox,
  Chip,
  Container,
  FormControl,
  FormControlLabel,
  FormLabel,
  InputLabel,
  ListItemText,
  MenuItem,
  OutlinedInput,
  Paper,
  Radio,
  RadioGroup,
  Select,
  Stack,
  TextField,
  ToggleButton,
  ToggleButtonGroup,
  Typography,
} from "@mui/material";
import PetsIcon from "@mui/icons-material/Pets";

import { useAuth } from "../provider/AuthProvider";
import { endpoints, getData, postData } from "../API/apiCalls";
import {
  BREED_TYPES,
  DOG_COLORS,
  DOG_SEXES,
  DOG_SIZES,
  REPORT_TYPES,
} from "../constants/constants";
import ValidationCaption from "./ValidationCaption";
 

const ColorDot = ({ color, size = 16, className }) => {
  return (
    <Box
      className={className}
      sx={{
        width: size,
        height: size,
        borderRadius: "50%",
        background: color,
        border: 1,
        borderColor: "divider",
        flexShrink: 0,
      }}
    />
  );
};
const DogReportForm = () => {
  const { setAlert } = useAuth();

  const [breedsList, setBreedsList] = useState([]);
  const [reportType, setReportType] = useState("");
  const [breedType, setBreedType] = useState("Unknown");
  const [breed, setBreed] = useState(null);
  const [sex, setSex] = useState("Unknown");
  const [size, setSize] = useState("");
  const [colors, setColors] = useState([]);
  const [validationErrors, setValidationErrors] = useState({});

  const nameRef = useRef();
  const chipNumberRef = useRef();
  const descriptionRef = useRef();

  useEffect(() => {
    getData(endpoints.getBreeds)
      .then((breeds) => setBreedsList(breeds))
      .catch((e) =>
        setAlert({
          message: e.message || "Hiba a fajták betöltése során!",
          severity: "error",
        })
      );
  }, []);

  const validateForm = (data) => {
    const errors = {};
    if (!data.reportType) errors.reportType = "Válaszd ki, hogy elveszett vagy talált kutyáról van szó!";
    if (data.chipNumber && data.chipNumber.length !== 15) errors.chipNumber = "A chipszám 15 számjegyből áll!";
    if (data.breedType === "Purebred" && !data.breedId) errors.breed = "Fajtatiszta kutyánál a fajta megadása kötelező!";
    if (!data.size) errors.size = "A méret megadása kötelező!";
    if (data.colors.length === 0) errors.colors = "Legalább egy színt válassz!";
    return errors;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const formData = {
      reportType,
      name: nameRef.current.value.trim() || null,
      breedType,
      breedId: breed?.id ?? null,
      sex,
      size,
      colors,
      chipNumber: chipNumberRef.current.value.trim() || null,
      description: descriptionRef.current.value.trim() || null,
    };

    const errors = validateForm(formData);
    if (Object.keys(errors).length > 0) {
      setValidationErrors(errors);
      return;
    }
    setValidationErrors({});

    await postData(endpoints.createDogReport, formData)
      .then(() => setAlert({ message: "Sikeres bejelentés!", severity: "success" }))
      .catch((e) =>
        setAlert({
          message: e.message || "Hiba a bejelentés során!",
          severity: "error",
        })
      );
  };

  const handleBreedChange = (e, value) => {
    setBreed(value);
    if (value) {
      setSize(value.size);
      setColors(value.colors);
    }
  };

  const handleBreedTypeChange = (e) => {
    setBreedType(e.target.value);
    if (e.target.value === "Unknown") setBreed(null);
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
              label="KUTYA BEJELENTÉSE"
              color="secondary"
              sx={{ fontWeight: "bold", py: 2, px: 4, fontSize: "1.25rem" }}
            />
            <Typography sx={{ color: "text.secondary" }}>
              Minél több adatot adsz meg, annál könnyebb megtalálni az adatbázisban.
            </Typography>
          </Stack>

          <Box
            component="form"
            noValidate
            onSubmit={handleSubmit}
            sx={{ display: "flex", flexDirection: "column", gap: 2.5 }}
          >
            <FormControl error={!!validationErrors.reportType}>
              <ToggleButtonGroup
                exclusive
                fullWidth
                value={reportType}
                onChange={(e, value) => value && setReportType(value)}
              >
                {Object.entries(REPORT_TYPES).map(([key, value]) => (
                  <ToggleButton
                    key={key}
                    value={key}
                    color={key === "Lost" ? "seeker" : "primary"}
                    sx={{ py: 1.5, fontWeight: 700 }}
                  >
                    {value}
                  </ToggleButton>
                ))}
              </ToggleButtonGroup>
              {validationErrors.reportType && (
                <ValidationCaption message={validationErrors.reportType} />
              )}
            </FormControl>

            <Stack direction={{ xs: "column", sm: "row" }} spacing={2}>
              <TextField
                fullWidth
                label="Név (ha ismert)"
                inputRef={nameRef}
                error={!!validationErrors.name}
                helperText={validationErrors.name}
              />
              <TextField
                fullWidth
                label="Chipszám"
                inputRef={chipNumberRef}
                slotProps={{ htmlInput: { maxLength: 15, minLength: 15 } }}
                error={!!validationErrors.chipNumber}
                helperText={validationErrors.chipNumber}
              />
            </Stack>

            <FormControl>
              <FormLabel id="breed-type-label">Fajta</FormLabel>
              <RadioGroup
                row
                aria-labelledby="breed-type-label"
                name="breedType"
                value={breedType}
                onChange={handleBreedTypeChange}
              >
                {Object.entries(BREED_TYPES).map(([key, value]) => (
                  <FormControlLabel key={key} value={key} control={<Radio />} label={value} />
                ))}
              </RadioGroup>
            </FormControl>

            <Autocomplete
              fullWidth
              options={breedsList}
              value={breed}
              onChange={handleBreedChange}
              getOptionLabel={(o) => o.name}
              isOptionEqualToValue={(o, v) => o.id === v.id}
              disabled={breedType === "Unknown"}
              loading={breedsList.length === 0}
              loadingText="Fajták betöltése..."
              noOptionsText="Nincs ilyen fajta"
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={breedType === "Mixed" ? "Melyik fajtára hasonlít?" : "Fajta*"}
                  error={!!validationErrors.breed}
                  helperText={validationErrors.breed}
                />
              )}
            />

            <FormControl>
              <FormLabel id="sex-label">Nem</FormLabel>
              <RadioGroup
                row
                aria-labelledby="sex-label"
                name="sex"
                value={sex}
                onChange={(e) => setSex(e.target.value)}
              >
                {Object.entries(DOG_SEXES).map(([key, value]) => (
                  <FormControlLabel key={key} value={key} control={<Radio />} label={value} />
                ))}
              </RadioGroup>
            </FormControl>

            <FormControl error={!!validationErrors.size}>
              <FormLabel sx={{ mb: 1 }}>Méret*</FormLabel>
              <ToggleButtonGroup
                exclusive
                fullWidth
                color="primary"
                value={size}
                onChange={(e, value) => value && setSize(value)}
              >
                {Object.entries(DOG_SIZES).map(([key, value]) => (
                  <ToggleButton key={key} value={key}>
                    {value}
                  </ToggleButton>
                ))}
              </ToggleButtonGroup>
              {validationErrors.size && <ValidationCaption message={validationErrors.size} />}
            </FormControl>

            <FormControl fullWidth error={!!validationErrors.colors}>
              <InputLabel id="colors-label">Színek*</InputLabel>
              <Select
                labelId="colors-label"
                multiple
                value={colors}
                onChange={(e) => setColors(e.target.value)}
                input={<OutlinedInput label="Színek*" />}
                renderValue={(selected) => (
                  <Box sx={{ display: "flex", flexWrap: "wrap", gap: 0.5 }}>
                    {selected.map((key) => (
                      <Chip
                        key={key}
                        size="small"
                        label={DOG_COLORS[key].label}
                        avatar={<ColorDot color={DOG_COLORS[key].color} />}
                      />
                    ))}
                  </Box>
                )}
              >
                {Object.entries(DOG_COLORS).map(([key, value]) => (
                  <MenuItem key={key} value={key}>
                    <Checkbox checked={colors.includes(key)} />
                    <ColorDot color={value.color} size={20} />
                    <ListItemText
                      primary={value.label}
                      secondary={breed?.colors.includes(key) ? "Jellemző a fajtára" : null}
                      sx={{ ml: 1.5 }}
                    />
                  </MenuItem>
                ))}
              </Select>
              {validationErrors.colors && <ValidationCaption message={validationErrors.colors} />}
            </FormControl>

            <TextField
              fullWidth
              multiline
              rows={4}
              label="Leírás"
              placeholder="Különleges ismertetőjelek, nyakörv, viselkedés..."
              inputRef={descriptionRef}
            />

            <Button
              type="submit"
              variant="contained"
              size="large"
              startIcon={<PetsIcon />}
              sx={{ py: 1.5, mt: 1 }}
            >
              Kutya bejelentése
            </Button>
          </Box>
        </Paper>
      </Container>
    </Box>
  );
};

export default DogReportForm;