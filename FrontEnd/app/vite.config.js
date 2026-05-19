import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server:{
    port:4606,
    // host:'0.0.0.0',
    // strictPort:true,
    // watch:{
    //   usePolling:true
    // }
  }
})
