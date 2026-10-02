import { Box } from "@mui/material";

const MapPin = ({ x, y, size, delay, dimAt, color }) => {
  return (
    <g transform={`translate(${x} ${y})`} opacity="1">
      {dimAt && (
        <animate
          attributeName="opacity"
          to="0.3"
          dur="0.6s"
          begin={`${dimAt}ms`}
          fill="freeze"
        />
      )}
      <Box component="g" sx={{ color, transition: "color .6s" }}>
        <ellipse
          rx={size * 1.6}
          ry={size * 0.55}
          fill="none"
          stroke="currentColor"
          strokeWidth="2"
          opacity="0"
        >
          <animate
            attributeName="rx"
            from={size * 0.16}
            to={size * 1.6}
            dur="1s"
            begin={`${delay}ms`}
            fill="freeze"
          />
          <animate
            attributeName="ry"
            from={size * 0.055}
            to={size * 0.55}
            dur="1s"
            begin={`${delay}ms`}
            fill="freeze"
          />
          <animate
            attributeName="opacity"
            values="0;1;0"
            keyTimes="0;0.2;1"
            dur="1s"
            begin={`${delay}ms`}
            fill="freeze"
          />
        </ellipse>
        <g transform="scale(0)">
          <animateTransform
            attributeName="transform"
            type="scale"
            values="0;1.1;1"
            keyTimes="0;0.7;1"
            dur="0.5s"
            begin={`${delay}ms`}
            fill="freeze"
          />
          <g transform={`scale(${size / 40}) translate(-20 -51)`}>
            <path
              d="M20 51 C20 51 2.5 32 2.5 19.5 A17.5 17.5 0 0 1 37.5 19.5 C37.5 32 20 51 20 51 Z"
              fill="currentColor"
              stroke="#151515"
              strokeWidth="1.5"
            />
            <circle cx="20" cy="19.5" r="12" fill="#151515" />
            <g fill="currentColor">
              <ellipse cx="20" cy="23.2" rx="5" ry="4.2" />
              <circle cx="13.6" cy="17.4" r="2.3" />
              <circle cx="17.6" cy="13.2" r="2.3" />
              <circle cx="22.4" cy="13.2" r="2.3" />
              <circle cx="26.4" cy="17.4" r="2.3" />
            </g>
          </g>
        </g>
      </Box>
    </g>
  );
};

export default MapPin;
