import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import LandingPage from './pages/LandingPage';
import Products from './pages/Products'


function NotFoundPage() { return <h2>😢 404 - Page Not Found</h2>; }

function App() {
  return (
    <BrowserRouter>
      {/* Anything placed outside <Routes> (like a Navbar) stays on screen permanently */}
      <nav style={{ padding: '10px', background: '#eee', display: 'flex', gap: '15px' }}>
        <a href="/">Home</a>
        <a href="/Products">Products</a>
      </nav>

      {/* The router checks the URL and swaps out the component below dynamically */}
      <Routes>
        {/* If the URL path is exactly "/" (homepage), display the LandingPage */}
        <Route path="/" element={<LandingPage />} />
        
        {/* If the URL path is "/products", display the ProductsPage */}
        <Route path="/Products" element={<Products />} />
        
        {/* The "*" captures any broken/unknown URLs and shows a 404 page */}
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App
