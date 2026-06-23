
import React, { useState } from 'react';

const RegistrationForm = () => {
  // 1. Single state object to track all form inputs efficiently
  const [formData, setFormData] = useState({
    username: '',
    firstName: '',
    lastName: '',
    email: '',
    password: '',
  });

  const [loading, setLoading] = useState(false);
  const [statusMessage, setStatusMessage] = useState('');
  const [isError, setIsError] = useState(false);

  // 2. Dynamic input handler that updates state based on the input's "name" attribute
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  // 3. Form Submit Handler
  const handleSubmit = async (e) => {
    e.preventDefault(); // Prevents the browser from reloading the page
    setLoading(true);
    setStatusMessage('');
    setIsError(false);

    const backendUrl = 'http://localhost:5000/api/User/register'; // Change this to your exact endpoint route

    try {
      const response = await fetch(backendUrl, {
        method: 'POST', // Creating data means we use POST
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData), // Converts our state object directly into raw JSON text
      });

      if (!response.ok) {
        throw new Error(`Server responded with status: ${response.status}`);
      }

      setStatusMessage('Registration successful!');
      // Reset form fields after successful registration
      setFormData({ username: '', firstName: '', lastName: '', email: '', password: '' });
    } catch (err) {
      console.error('Registration Error:', err);
      setIsError(true);
      setStatusMessage('Registration failed. Ensure your backend is running and CORS is configured.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ maxWidth: '400px', margin: '40px auto', padding: '20px', border: '1px solid #ccc', borderRadius: '8px' }}>
      <h2 style={{ textAlign: 'center' }}>Create an Account</h2>
      
      <form onSubmit={handleSubmit}>
        <div style={{ marginBottom: '15px' }}>
          <label style={{ display: 'block', marginBottom: '5px' }}>Username</label>
          <input
            type="text"
            name="username"
            value={formData.username}
            onChange={handleChange}
            required
            style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }}
          />
        </div>

        <div style={{ marginBottom: '15px' }}>
          <label style={{ display: 'block', marginBottom: '5px' }}>First Name</label>
          <input
            type="text"
            name="firstName"
            value={formData.firstName}
            onChange={handleChange}
            required
            style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }}
          />
        </div>

        <div style={{ marginBottom: '15px' }}>
          <label style={{ display: 'block', marginBottom: '5px' }}>Last Name</label>
          <input
            type="text"
            name="lastName"
            value={formData.lastName}
            onChange={handleChange}
            required
            style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }}
          />
        </div>

        <div style={{ marginBottom: '15px' }}>
          <label style={{ display: 'block', marginBottom: '5px' }}>Email Address</label>
          <input
            type="email"
            name="email"
            value={formData.email}
            onChange={handleChange}
            required
            style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }}
          />
        </div>

        <div style={{ marginBottom: '20px' }}>
          <label style={{ display: 'block', marginBottom: '5px' }}>Password</label>
          <input
            type="password"
            name="password"
            value={formData.password}
            onChange={handleChange}
            required
            style={{ width: '100%', padding: '8px', boxSizing: 'border-box' }}
          />
        </div>

        <button
          type="submit"
          disabled={loading}
          style={{
            width: '100%',
            padding: '10px',
            backgroundColor: loading ? '#ccc' : '#28a745',
            color: 'white',
            border: 'none',
            borderRadius: '4px',
            fontSize: '16px',
            cursor: loading ? 'not-allowed' : 'pointer',
          }}
        >
          {loading ? 'Submitting...' : 'Register'}
        </button>
      </form>

      {statusMessage && (
        <p style={{ marginTop: '15px', color: isError ? 'red' : 'green', textAlign: 'center' }}>
          {statusMessage}
        </p>
      )}
    </div>
  );
};

export default RegistrationForm;