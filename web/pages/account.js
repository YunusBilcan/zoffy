import React, { useEffect, useState } from "react";
import RootLayout from "../app/layout";
const Account = () => {
  const [userData, setUserData] = useState(null);

  useEffect(() => {
    fetch(
      `http://localhost:5175/api/User/${window.sessionStorage
        .getItem("sessionId")
        .toString()}`,
      {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
      }
    )
      .then((response) => response.json())
      .then((data) => setUserData(data))
      .catch((error) => console.log(error));
  }, []);

  return (
    <RootLayout>
      <div>
        {userData && (
          <div>
            <p>Hoşgeldiniz {userData.name}</p>
            <img
              src={userData.userPicture}
              alt="User Picture"
              style={{ width: "50px", borderRadius: "500px" }}
            />
          </div>
        )}
      </div>
    </RootLayout>
  );
};

export default Account;
