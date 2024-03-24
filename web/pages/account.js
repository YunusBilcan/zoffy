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