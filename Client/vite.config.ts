import { defineConfig } from "vite";
import mkcert from "vite-plugin-mkcert";
import babel from "@rolldown/plugin-babel";
import react, { reactCompilerPreset } from "@vitejs/plugin-react";

export default defineConfig({
  server: {
    port: 3000,
  },
  plugins: [react(), mkcert(), babel({ presets: [reactCompilerPreset()] })],
});
