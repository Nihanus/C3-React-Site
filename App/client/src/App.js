/*
Made by: Ignas Budzinskas
*/
import React, {Fragment} from "react";
import "./index.css"
import {Route, BrowserRouter, Routes} from "react-router-dom";
import { Home } from "./components/Home";
import { NavBar } from "./components/NavBar";
import { Reserve } from "./components/BookReservation";
import { ReservationList } from "./components/ReservationList";

export default function App() {
  return (
    <BrowserRouter>
        <NavBar/>
        <Routes>
        <Route path="/" Component={Home}/>
        <Route path="/reservations" Component={ReservationList}/>
        <Route exact path="/book/:id" Component={Reserve}/>
        </Routes>
     </BrowserRouter>
  );
}