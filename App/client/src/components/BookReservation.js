import React, {Component, useEffect, useState} from "react";
import { Path } from "./APIPath";
import { Button, Checkbox, TextField } from "@mui/material";
import { useParams } from "react-router-dom";
import {DemoContainer} from '@mui/x-date-pickers/internals/demo';
import {AdapterDayjs} from '@mui/x-date-pickers/AdapterDayjs';
import dayjs, {Dayjs} from "dayjs";
import {LocalizationProvider} from '@mui/x-date-pickers/';
import { DatePicker } from '@mui/x-date-pickers/';
import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import Switch from '@mui/material/Switch';
import {Radio} from "@mui/material";
import {RadioGroup} from "@mui/material";
import { Alert } from "@mui/material";
import { Link } from "react-router-dom";

export function Reserve(){
    const id = useParams();
    const [book, setBook] = useState({});
    const [type, setType] = useState("book");
    const [loading, setLoading] = useState(true);
    const [startDate, setStartDate] = useState(dayjs());
    const [endDate, setEndDate] = useState(dayjs());
    const [pickUp, setPickUp] = useState(true);
    const [err, setErr] = useState(false);

    const handleChange = (event) =>{
        setType(event.target.value);
    };

    const handleCheck = (event) =>{
        setPickUp(event.target.checked);
    };

    //There is a off by one error when the dates get parsed to JSON
    const handlePress = (event) =>{
        console.log(startDate.toDate())
        const temp = startDate.toDate();

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                "bookname": book.bookName,
                "startday": startDate,
                "endday": endDate,
                "quickpickup": pickUp,
                "typeofbook": type
            })
        };
        console.log(requestOptions);
        fetch(Path+'bookreservation', requestOptions)
        .then(response => {
            if(response.ok){
                return console.log(response.json);
            }
            throw response;
        })
        .catch(error => {
            console.log(error);
            console.error("Failled to post reservation");
        })

        
    };
    useEffect(() =>{
        fetch(Path+'book/'+id.id)
        .then(response =>{
            if(response.ok){
                return response.json();
            }
            throw response;
        })
        .then(data =>{
            setBook(data);
        })
        .catch(error => {
            console.error("Failed to fetch book");
        })
        .finally(() =>
        setLoading(false));
    },
    []);
    if(loading){
        return "Loading...";
    }
    return(
        <>
        <div style={{display: 'flex', alignItems: 'center', justifyContent: 'center'}}><h1>Book reservation</h1></div>
        <p style={{display: 'flex', alignItems: 'center', justifyContent: 'center'}}>Book name: <b>{book.bookName}</b></p>
        <div style={{display: 'flex', alignItems: 'center', justifyContent: 'center'}}>
        <LocalizationProvider dateAdapter={AdapterDayjs}>
            <DemoContainer components={['DatePicker']}>
                <DatePicker selected={startDate} onChange={(date) => setStartDate(date)} label="Start day"/>
            </DemoContainer>
        </LocalizationProvider>
        <LocalizationProvider dateAdapter={AdapterDayjs}>
            <DemoContainer components={['DatePicker']}>
                <DatePicker selected={endDate} onChange={(date) => setEndDate(date)} label="End day"/>
            </DemoContainer>
        </LocalizationProvider>
        </div>
        <FormGroup style={{display: 'flex', alignItems: 'center', justifyContent: 'center'}}>
            <RadioGroup value={type} onChange={handleChange}>
                <FormControlLabel value="book" control={<Radio/>} label="Book"/>
                <FormControlLabel value="audiobook" control={<Radio/>} label="Audiobook"/>
            </RadioGroup>
            <FormControlLabel control={<Checkbox checked={pickUp} onChange={handleCheck}/>} label="Quick pick up"/>
            {console.log(pickUp)}
        </FormGroup>
        <div style={{display: 'flex', alignItems: 'center', justifyContent: 'center'}}>
            <Button variant="contained" onClick={handlePress} style={{margin: '5px'}}>Submit</Button>
            <Button variant="contained" component={Link} to="/" style={{margin: '5px'}}>Back</Button>
        </div>
        </>
    );
}