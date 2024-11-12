const NameList = ({ names }) => {
  return (
    <div className="name-wrap">
      <h1>My Names</h1>
      <ul>
        {names.map((name, index) => (
          <li style={{ listStyle: "none" }} key={index}>
            {name}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default NameList;
