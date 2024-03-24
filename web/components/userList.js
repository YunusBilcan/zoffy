import React from 'react';

const HelloWorld = () => {
    const [userData, setUserData] = React.useState(null);

    React.useEffect(() => {
        fetch('http://localhost:5175/api/User')
            .then(response => response.json())
            .then(data => setUserData(data))
            .catch(error => console.log(error));
    }, []);

    return (
        <div>
            {userData && (
                <ul>
                    {userData.map(user => (
                        <li key={user.id}>{user.name}</li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default HelloWorld;