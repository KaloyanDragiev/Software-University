function solve(dataRows){
    let ballot = new Map();

    for (let line of dataRows){
        let system = line.system;
        let candidate = line.candidate;
        let votes = Number(line.votes);

        if (!ballot.has(system))
            ballot.set(system, new Map());
        if (!ballot.get(system).has(candidate))
            ballot.get(system).set(candidate, 0);
        let oldVotes = ballot.get(system).get(candidate);
        ballot.get(system).set(candidate, oldVotes + votes);
    }

    let ballotForCountingVotes = new Map();
    for (let [system, candidateInfo] of ballot){
        let orderedTotalVotes = Array.from(candidateInfo).sort((a, b) => b[1] - a[1]);
        let totalSystemVotes = 0;
        for (let [candidate, votes] of candidateInfo)
            totalSystemVotes += votes;
        let firstPlaceCandidate = orderedTotalVotes[0][0];
        if (!ballotForCountingVotes.has(firstPlaceCandidate))
            ballotForCountingVotes.set(firstPlaceCandidate, new Map());
        ballotForCountingVotes.get(firstPlaceCandidate).set(system, totalSystemVotes);
    }

    let winnersBallot = new Map();
    for (let [candidate, systemVotes] of ballotForCountingVotes){
        let totalCandidateVoteCount = Array.from(systemVotes.values()).reduce((a, b) => a + b);
        winnersBallot.set(candidate, totalCandidateVoteCount);
    }

    if (winnersBallot.size == 1){
        let winner = Array.from(winnersBallot)[0];
        console.log(`${winner[0]} wins with ${winner[1]} votes`);
        console.log(`${winner[0]} wins unopposed!`);
        return;
    }

    let topTwoCandidates = Array.from(winnersBallot).sort((a, b) => b[1] - a[1]);
    let firstPlaceCandidate = topTwoCandidates[0][0];
    let firstPlaceVotes = topTwoCandidates[0][1];
    let secondPlaceCandidate = topTwoCandidates[1][0];
    let secondPlaceVotes = topTwoCandidates[1][1];

    let totalSystemVotes = 0;
    for (let [system, candidateAndVotes] of ballot){
        for (let [candidate, votes] of candidateAndVotes)
            totalSystemVotes += votes;
    }

    let firstCandidatePercentage = Math.floor((firstPlaceVotes / totalSystemVotes) * 100);
    let secondCandidatePercentage = Math.floor((secondPlaceVotes / totalSystemVotes) * 100);

    if (firstPlaceVotes * 2 > totalSystemVotes){
        console.log(`${firstPlaceCandidate} wins with ${firstPlaceVotes} votes`);
        console.log(`Runner up: ${secondPlaceCandidate}`);
        let sortedSystemWins = Array.from(ballotForCountingVotes.get(secondPlaceCandidate)).sort((a, b) => b[1] - a[1]);
        for (let [system, votes] of sortedSystemWins){
            console.log(`${system}: ${votes}`)
        }//
    }
    else{
        console.log(`Runoff between ${firstPlaceCandidate} with ${firstCandidatePercentage}% and ${secondPlaceCandidate} with ${secondCandidatePercentage}%`)
    }
}