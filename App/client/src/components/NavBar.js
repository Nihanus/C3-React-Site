import React from "react";
import { AppBar } from "@mui/material";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import { Outlet, Link } from "react-router-dom";

export const NavBar = () =>{
    return(
        <Box>
            <AppBar position="static">
                <Toolbar>
                    <Typography variant="h6" component="div" sx={{flexGrow: 1}}>
                        Main App
                    </Typography>
                    <Button color="inherit" component={Link} to ="/">Home</Button>
                    <Button color="inherit" component={Link} to="/reservations">My reservations</Button>
                </Toolbar>
            </AppBar>
        </Box>
    );
}