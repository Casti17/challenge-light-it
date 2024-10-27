import "./App.css";
import React, { useState, useEffect } from "react";
import UserList from "./components/userList/userList";
import AddUserForm from "./components/userForm/userForm";
import { getAllPatients } from "./services/patientsService";

const App: React.FC = () => {
  const [users, setUsers] = useState<any[]>([]);

  const fetchUsers = async () => {
    try {
      const fetchedUsers = await getAllPatients();
      setUsers(fetchedUsers);
      localStorage.setItem("users", JSON.stringify(fetchedUsers));
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  const handleAddUser = () => {
    fetchUsers();
  };

  return (
    <div className="main">
      <h1>User Registration</h1>
      <AddUserForm onAddUser={handleAddUser} />
      <h2>User List</h2>
      <UserList users={users} />
    </div>
  );
};

export default App;
