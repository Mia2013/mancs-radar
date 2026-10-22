export const ROLES = {
    GUEST: "guest",
    USER: "user",
    ADMIN: "admin",
    SHELTER: "shelter",
};

 
export const ALL_ROLES = Object.values(ROLES);


export const BREED_TYPES = {
    Purebred: "Fajtatiszta",
    Mixed: "Keverék",
    Unknown: "Nem tudom",
};

export const REPORT_TYPES = {
    Lost: "Elveszett",
    Found: "Talált",
};

export const DOG_SEXES = {
    Male: "Kan",
    Female: "Szuka",
    Unknown: "Nem tudom",
};

export const DOG_SIZES = {
    Small: "Kicsi",
    Medium: "Közepes",
    Large: "Nagy",
};

export const DOG_COLORS = {
    Black: { label: "Fekete", color: "#151515" },
    White: { label: "Fehér", color: "#FFFFFF" },
    Brown: { label: "Barna", color: "#7B4A2A" },
    Grey: { label: "Szürke", color: "#9E9E9E" },
    Gold: { label: "Sárga", color: "#E3B04B" },
    Red: { label: "Vörös", color: "#B5532A" },
    Brindle: { label: "Csíkos", color: "repeating-linear-gradient(45deg, #5A3A1E 0 4px, #C99A5B 4px 8px)" },
};
