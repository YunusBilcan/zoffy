import React, { useState } from "react";
import { TextField, Button } from "@mui/material";

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
        alert("Başarılı!");
        const sessionId = await response.text();
        sessionStorage.setItem("sessionId", sessionId);
        window.location.href = "/account";
      } else {
        alert("Başarısız!");
        console.error("Error:", response.status);
      }
    }
    catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <div>
      <TextField label="Email" value={Email} onChange={handleEmailChange} />
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
  );
};

export default Login;
