import React, { useState } from 'react';
import axios from 'axios';
import { TextField, Button } from '@mui/material';
import RootLayout from '../app/layout';

// Define the UserCreate component
const UserCreate = () => {
  // Define the state variables for the form inputs
  const [nickname, setNickname] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [name, setName] = useState('');
  const [surname, setSurname] = useState('');
  const [tc, setTc] = useState(0);
  const [address, setAddress] = useState('');
  const [phone, setPhone] = useState('');
  const [salary, setSalary] = useState('');
  const [job, setJob] = useState('');

  // Function to handle form submission
  const handleSubmit = async (e) => {
    e.preventDefault();

    // Create the user object
    const user = {
      nickname,
      email,
      password,
      name,
      surname,
      tc,
      address,
      phone,
      salary,
      job
    };

    try {
      // Send a POST request to the API
      const response = await axios.post('http://localhost:5175/api/User', user);
      console.log(response.data); // Handle the response as needed

      if (response.status === 200) {
        alert("User created successfully");
      }
    } catch (error) {
      console.error(error); // Handle any errors that occur during the request
    }
  };

  // Render the form
  return (
    <RootLayout>

    <div>
      <form onSubmit={handleSubmit}>
        <div>
          <TextField label="Nickname" value={nickname} onChange={(e) => setNickname(e.target.value)} />
        </div>
        <div>
          <TextField label="Email" value={email} onChange={(e) => setEmail(e.target.value)} />
        </div>
        <div>
          <TextField label="Password" type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
        </div>
        <div>
          <TextField label="Name" value={name} onChange={(e) => setName(e.target.value)} />
        </div>
        <div>
          <TextField label="Surname" value={surname} onChange={(e) => setSurname(e.target.value)} />
        </div>
        <div>
          <TextField label="TC" type="number" value={tc} onChange={(e) => setTc(e.target.value)} />
        </div>
        <div>
          <TextField label="Address" value={address} onChange={(e) => setAddress(e.target.value)} />
        </div>
        <div>
          <TextField label="Phone" value={phone} onChange={(e) => setPhone(e.target.value)} />
        </div>
        <div>
          <TextField label="Salary" value={salary} onChange={(e) => setSalary(e.target.value)} />
        </div>
        <div>
          <TextField label="Job" value={job} onChange={(e) => setJob(e.target.value)} />
        </div>
        <div>
          <Button type="submit" variant="contained" color="primary">Submit</Button>
        </div>
      </form>
    </div>
    </RootLayout>

  );
};

export default UserCreate;
