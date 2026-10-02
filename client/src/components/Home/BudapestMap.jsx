const ROADS = [
    { d: "M 560 40 C 1000 50, 1100 560, 690 640", width: 7 },
    { d: "M 575 172 C 760 186, 800 380, 618 470", width: 6 },
    { d: "M 592 285 C 670 300, 680 400, 606 432", width: 4 },
    { d: "M 640 300 L 1010 110", width: 4 },
    { d: "M 650 360 L 1312 330", width: 6 },
    { d: "M 640 410 L 1180 680", width: 5 },
    { d: "M 600 180 L 960 0", width: 4 },
    { d: "M 548 170 L 280 110 L 0 90", width: 4 },
    { d: "M 548 322 L 420 330 L 200 380 L 0 400", width: 4 },
    { d: "M 560 440 L 400 560 L 260 680", width: 6 },
    { d: "M 530 230 C 470 250, 460 330, 520 400 C 540 430, 560 450, 565 500", width: 3 },
];

const HILLS = [
    { cx: 200, cy: 200, rx: 170, ry: 110 },
    { cx: 200, cy: 200, rx: 120, ry: 72 },
    { cx: 200, cy: 200, rx: 70, ry: 38 },
    { cx: 380, cy: 470, rx: 110, ry: 70 },
    { cx: 380, cy: 470, rx: 60, ry: 36 },
];

const BRIDGES = [[528, 170], [548, 322], [552, 380], [563, 440], [578, 500], [612, 592]];

const RIVER = "M 520 -20 C 545 60, 575 180, 585 280 S 595 420, 630 540 S 690 650, 720 700";

const BudapestMap = ({ labels }) => {
    return (
        <>
            <defs>
                <pattern id="pest-grid" width="44" height="44" patternUnits="userSpaceOnUse" patternTransform="rotate(-12)">
                    <path d="M 0 0 L 44 0 M 0 0 L 0 44" stroke="#202024" strokeWidth="1.5" fill="none" />
                </pattern>
                <pattern id="buda-grid" width="70" height="52" patternUnits="userSpaceOnUse" patternTransform="rotate(24)">
                    <path d="M 0 0 L 70 0 M 0 0 L 0 52" stroke="#1d1d20" strokeWidth="1.5" fill="none" />
                </pattern>
            </defs>
            <rect width="1312" height="680" fill="#161618" />
            <rect width="600" height="680" fill="url(#buda-grid)" />
            <rect x="580" width="732" height="680" fill="url(#pest-grid)" />
            {HILLS.map((hill) => (
                <ellipse key={`${hill.cx}-${hill.rx}`} {...hill} fill="none" stroke="#1e1e21" strokeWidth="2" />
            ))}
            {ROADS.map((road) => (
                <path key={road.d} d={road.d} stroke="#2c2c30" strokeWidth={road.width} fill="none" />
            ))}
            <path d={RIVER} stroke="#1b2730" strokeWidth="54" fill="none" strokeLinecap="round" />
            <ellipse cx="552" cy="92" rx="11" ry="64" transform="rotate(-17 552 92)" fill="#1b1b1e" stroke="#2c2c30" strokeWidth="2" />
            {BRIDGES.map(([x, y]) => (
                <line key={y} x1={x} y1={y} x2={x + 80} y2={y} stroke="#3c3c41" strokeWidth="6" />
            ))}
            <text x={labels.buda.x} y={labels.buda.y} fill="#55555c" fontFamily="Baloo 2" fontWeight="600" fontSize="28" letterSpacing="12">BUDA</text>
            <text x={labels.pest.x} y={labels.pest.y} fill="#55555c" fontFamily="Baloo 2" fontWeight="600" fontSize="28" letterSpacing="12">PEST</text>
            <text transform="translate(604 262) rotate(80)" fill="#3d5361" fontFamily="Figtree" fontStyle="italic" fontSize="15" letterSpacing="3">Duna</text>
        </>
    );
};

export default BudapestMap;
