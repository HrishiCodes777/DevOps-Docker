import React, { useState } from 'react';

const InputBox = ({ addName }) => {
  const [name, setName] = useState("");

  const handleInputChange = (e) => {
    setName(e.target.value);
  };

  const handleAddName = () => {
    //console.log("Name in input box", name);
    if (name.trim()) {
      addName(name);
      setName("");
    }
  };

  return (
    <div className="input-wrapper">
      <input
        type="text"
        placeholder="Enter your name"
        value={name}
        onChange={handleInputChange}
      />
      <button onClick={handleAddName}>Add</button>
    </div>
  );
};

export default InputBox;
