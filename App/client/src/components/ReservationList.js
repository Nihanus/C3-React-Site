import React, {Component} from "react";
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { Path } from "./APIPath";
import { Link } from "react-router-dom";

export class ReservationList extends Component {
    static displayName = ReservationList.name;
    constructor(props){
        super(props);
        this.state = {reservations: [], loading: true};
    }

    componentDidMount(){
        this.populateReservationData();
    }

    static formateDate(string) {
        let options = { year: 'numeric', month: 'numeric', day: 'numeric'}
        return new Date(string).toLocaleDateString([], options);
    }

    static renderReservations(reservations){
        return(
            <>
            <TableContainer component={Paper} elevation={3}>
                <Table aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell>Book name</TableCell>
                            <TableCell>Start day</TableCell>
                            <TableCell>End day</TableCell>
                            <TableCell>Quick pick up</TableCell>
                            <TableCell>Price</TableCell>
                            <TableCell>Type</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {reservations.map(reservation =>
                            <TableRow key={reservation.id}>
                                <TableCell>{reservation.bookName}</TableCell>
                                <TableCell>{this.formateDate(reservation.startDay)}</TableCell>
                                <TableCell>{this.formateDate(reservation.endDay)}</TableCell>
                                <TableCell>{reservation.quickPickUp+""}</TableCell>
                                <TableCell>{reservation.priceOfBook}</TableCell>
                                <TableCell>{reservation.typeofBook}</TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </TableContainer>
            </>
        );
    }

    render(){
        let contents = this.state.loading ? <p><em>Loading...</em></p> : ReservationList.renderReservations(this.state.reservations);
        return(
            <>
            <div>
                <h1 id="tableLabel" style={{display: 'flex', alignItems: 'center', justifyContent: 'center'}}>Book reservations</h1>
                {contents}
            </div>
            </>
        );
    }

    async populateReservationData(){
        const response = await fetch(Path+'bookreservation/reservations');
        const data = await response.json();
        this.setState({reservations: data, loading: false});
    }
}