import React, { useState } from "react";
import { TextField, Button } from "@mui/material";
import RootLayout from "../app/layout";

const Login = () => {
  const [Email, setEmail] = useState("");
  const [Password, setPassword] = useState("");

  const handleEmailChange = (event) => {
    setEmail(event.target.value);
  };

  const handlePasswordChange = (event) => {
    setPassword(event.target.value);
  };

  const handleSubmit = async () => {
    try {
    const response = await fetch("http://localhost:5175/api/Login", {
      method: "Post",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        email: Email,
        password: Password,
      }),
    });

      if (response.status === 200) {
        const data = await response.text();
        const sessionId = data;
        window.sessionStorage.setItem("sessionId", sessionId);
        window.location.href = "/account";
      } else {
        alert("Başarısız!");
      }
    } catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <RootLayout>

    <div>
      <TextField
        label="Email"
        value={Email}
        onChange={handleEmailChange}
      />
      <TextField
        label="Password"
        type="password"
        value={Password}
        onChange={handlePasswordChange}
      />
      <Button variant="contained" color="primary" onClick={handleSubmit}>
        Submit
      </Button>
    </div>
    </RootLayout>

  );
};

export default Login;
