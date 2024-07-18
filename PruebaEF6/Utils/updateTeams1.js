async function updateTeams1() {
    const countryId = await $("#LeagueSelector").val();
    let response = await fetch(urlGetTeams + "?id=" + countryId, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ "id": countryId })
    })
    const json = await response.json();
    const leagues = json.map(league => `<option value="${league.Value}">${league.Text}</option>`);
    $("#TeamSelector").html(leagues);
}