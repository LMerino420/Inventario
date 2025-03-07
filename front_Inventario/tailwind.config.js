const defaultTheme = require("tailwindcss/defaultTheme");

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"],
  theme: {
    extend: {
      colors: {
        water: {
          DEFAULT: "#132886",
          950: "#172554",
          900: "#1E3A8A",
          800: "#1E40AF",
          700: "#1D4ED8",
          600: "#2563EB",
          500: "#3B82F6",
          400: "#60A5FA",
          300: "#93C5FD",
          200: "#BFDBFE",
          100: "#DBEAFE",
        },
        oasis: {
          DEFAULT: "#79D2EC",
          950: "#06242D",
          900: "#0C485A",
          800: "#136C86",
          700: "#1990B3",
          600: "#1FB4E0",
          500: "#4CC3E6",
          400: "#79D2EC",
          300: "#A5E1F3",
          200: "#D2F0F9",
          100: "#E9F8FC",
        },
        sun: {
          DEFAULT: "#FDDB68",
          950: "#422006",
          900: "#713F12",
          800: "#854D0E",
          700: "#A16207",
          600: "#CA8A04",
          500: "#EAB308",
          400: "#FDE047",
          300: "#FEE79A",
          200: "#FEF08A",
          100: "#FEF9C3",
        },
        neutral: {
          DEFAULT: "#666666",
          950: "#0A0A0A",
          900: "#171717",
          800: "#262626",
          700: "#404040",
          600: "#525252",
          500: "#737373",
          400: "#A3A3A3",
          300: "#D4D4D4",
          200: "#E5E5E5",
          100: "#F5F5F5",
        },
        error: {
          DEFAULT: "#E85555",
        },
        success: {
          60: "#009E38",
          40: "#006323",
        },
      },
    },
    fontFamily: {
      arimo: ["Arimo", ...defaultTheme.fontFamily.sans],
    },
  },
  plugins: [],
};
