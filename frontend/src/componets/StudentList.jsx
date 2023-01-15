import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom';
function StudentList() {
    const [stud,setStud]=useState([]);
    const url="http://localhost:5118/Student";

    useEffect(()=>{
        axios.get(url).then((resp)=>{
         console.log(resp.data) 
          setStud(resp.data) 
        })
    
      },[])
    const renderdata=()=>{
        return (stud.map((s)=>{
            return (
                <tr key={s.name}>
                    <td>{s.name}</td>
                    <td>{s.rollno}</td>
                    <td>{s.email}</td>
                    <td>{s.batch}</td>
                </tr>
            )
        })

        )
    }


  return (
    <div className='app'>
    <h1>Student List </h1>
    <Link to="/Addstudent" > <button type='button' >Add Student</button></Link>
    <table border='2px'>
        {
        renderdata()
        }
    </table>
    </div>
  )
}

export default StudentList