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

export class Home extends Component{
    static displayName = Home.name;
    constructor(props){
        super(props);
        this.state = {books: [], loading: true};
    }

    componentDidMount(){
        this.populateBookData();
    }

    static renderBookList(books){
        return(
            <TableContainer component={Paper} elevation={3}>
                <Table aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell></TableCell>
                            <TableCell>Name</TableCell>
                            <TableCell>Year of release</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {books.map(book =>
                            <TableRow key={book.id}>
                                <TableCell component={Link} to={'/book/'+book.id}><img src={book.imgPath} alt="Image of book" width="200px"/></TableCell>
                                <TableCell component={Link} to={'/book/'+book.id}>{book.bookName}</TableCell>
                                <TableCell>{book.releaseYear}</TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </TableContainer>
        );
    }

    render(){
        let contents = this.state.loading ? <p><em>Loading ...</em></p> : Home.renderBookList(this.state.books);
        return(
            <div>
                <h1 id="tableLabel">Book list</h1>
                {contents}
            </div>
        );
    }

    async populateBookData(){
        const response = await fetch(Path+'book');
        const data = await response.json();
        this.setState({books: data, loading: false});
    }
}