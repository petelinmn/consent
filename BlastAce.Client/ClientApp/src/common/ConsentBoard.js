import React, { useEffect, useState } from 'react'

const userId = 'JohnDoe'

const Flows = ({onChangeFlow}) => {
  const [flows, setFlows] = useState()

  useEffect(() => {
    fetch('https://localhost:7299/service/v1/flow')
      .then(x => x.json())
      .then(flows => {
        setFlows(flows);
        if (onChangeFlow) {
          onChangeFlow(flows[0])
        }
      })
  }, [])

  return (
    <div>
      <select onChange={e => {
        onChangeFlow(flows.find(f => f.name === e.target.value))
      }}>
        {flows?.map(flow => (
          <option>
            {flow.name}
          </option>
        ))}
      </select>
    </div>
  )
}


const PolicyUnsigned = ({appId, flowId, userId}) => {
  const [policies, setPolicies] = useState([]);

  useEffect(() => {
    fetch(`https://localhost:7299/api/v1/decisions3/${appId}/${flowId}/${userId}`)
      .then(x => x.json())
      .then(policies => {
        setPolicies(policies);
        console.log(policies)
        //if (onChangeFlow) {
          //onChangeFlow(decisions[0])
        //}
      })
  }, [appId, flowId, userId])
console.log(policies)
  return (
    <div>
      <ul>
        {policies?.map(p => (
          <li>
            {p.policy.name}
          </li>
        ))}
      </ul>
    </div>
  )
}


const ConsentBoard = ({appId}) => {

  const [flow, setFlow] = useState();
  /*const [decisions, setDecisions] = useState([])

  useEffect(() => {
    fetch(`https://localhost:7299/api/v1/decisions/1/1`)
      .then(x => x.json())
      .then(d => console.log(d) || setDecisions(d))
  }, [])*/

  console.log(flow)

  if (!flow)
    return (
      <div>
        <h2>loading...</h2>
        <Flows onChangeFlow={flow => setFlow(flow)} />
      </div>
    )

  return (
    <div>
      <h1>Application: {appId}</h1>
      <h1>Flow: {flow?.name}</h1>

      <Flows onChangeFlow={flow => setFlow(flow)} />

      <PolicyUnsigned appId={appId} userId={'QQQQ'} flowId={flow?.name} />
    </div>
  )
}
  
export { ConsentBoard };
