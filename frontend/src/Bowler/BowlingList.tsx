import { useEffect, useState } from 'react';
import { Bowler } from '../types/Bowler';

function BowlingList() {
  const [bowlerData, setBowlerData] = useState<Bowler[]>([]);
  useEffect(() => {
    const fetchBowlerData = async () => {
      const response = await fetch('http://localhost:5089/Bowler');
      const data = await response.json();
      setBowlerData(data);
    };

    fetchBowlerData();
  }, []);

  return (
    <>
      <div className="row">
        <h4 className="text-center">Our Bowling League</h4>
      </div>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Full Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {bowlerData.map((bowler, index) => (
            <tr key={index}>
              <td>{bowler.fullName}</td>
              <td>{bowler.teamName}</td>
              <td>{bowler.bowlerAddress}</td>
              <td>{bowler.bowlerCity}</td>
              <td>{bowler.bowlerState}</td>
              <td>{bowler.bowlerZip}</td>
              <td>{bowler.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default BowlingList;
