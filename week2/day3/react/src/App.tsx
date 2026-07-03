import "./App.scss";

import Developers from "./pages/Developres";
import HomePage from "./pages/HomePage";
import UpperNav from "./pages/UpperNav";
import Dialog from "./components/Dialog";
import { useState } from "react";
import { Route, Routes } from "react-router-dom";
import { Name } from "./context/Name";

function App() {
  const [open, setOpen] = useState(true);
  const [userName, setUserName] = useState("");
  console.log(userName);
  return (
      <Name.Provider
        value={{ name: userName, setName: setUserName, setOpen: setOpen }}
      >
        <UpperNav />
        <main className="main" style={{}}>
          <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/developers" element={<Developers />} />
          </Routes>
          {open && <Dialog description="Enter Your Name." btnText="Submit" />}
        </main>
      </Name.Provider>
  );
}

export default App;
