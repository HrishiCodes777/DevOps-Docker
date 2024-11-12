import './App.css';
import InputBox from './components/InputBox';
import NameList from './components/NameList';
import { useState, useEffect } from 'react';
import { getAllUsers } from './services/apiService';
import { addName } from './services/apiService';

function App() {
  const [nameList, setNameList] = useState([]);

  useEffect(() => {
    const fetchUsers = async () => {
      const users = await getAllUsers();
      if (users) {
        setNameList(users.map(user => user.name));
      }
    };
    
    fetchUsers();
  }, []);

  const handleAddName = async (newName) => {
    try {
      // console.log(`Adding name in App: ${newName}`);
      const addedUser = await addName(newName); 
      if (addedUser) {
        setNameList((prevNames) => [...prevNames, addedUser.name]);
      }
    } catch (error) {
      console.log(error.message);
    }
  };

  return (
    <div className="App">
      <center>
        <InputBox addName={handleAddName} />
        <NameList names={nameList} />
      </center>
    </div>
  );
}

export default App;
