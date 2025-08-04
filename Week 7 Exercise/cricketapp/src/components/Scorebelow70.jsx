import React from 'react'

const Scorebelow70 = ({players}) => {
 return (
    players.map((item)=>{
        if (item.score < 70) {
            return (
                    <div>
                        <li>Mr. {item.name}<span> {item.score} </span></li>
                    </div>
                );
        }})
    )
}

export default Scorebelow70
