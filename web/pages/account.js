<<<<<<< HEAD
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
=======
import React, { useEffect, useState } from 'react';

const Account = () => {
            const [userData, setUserData] = useState(null);

            useEffect(() => {
                fetch('http://localhost:5175/api/User', {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                        'id': window.sessionStorage.getItem('sessionId').toString()
                    }
                })
                .then(response => response.json())
                .then(data => setUserData(data))
                .catch(error => console.log(error));
            }, []);

            return (
                <div>
                    {userData && (
                        <div>
                            <h1>Hello, World!</h1>
                            <p>ID: {userData.id}</p>
                            <p>Nickname: {userData.nickname}</p>
                            <p>Email: {userData.email}</p>
                        </div>
                    )}
                </div>
            );
        };

export default Account;
>>>>>>> ef125a3cde044403fae8ef5fc66a3af2e4cf0343
