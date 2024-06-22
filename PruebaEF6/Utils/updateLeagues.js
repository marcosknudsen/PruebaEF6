async function updateLeagues() {
    const countryId = $("#selectCountry").val();
    let response = await fetch(urlGetLeagues, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ "id": countryId })
    })
    const json = await response.json();
    const leagues = json.map(league => `<option value="${league.Value}">${league.Text}</option>`);
    $("#selectLeague").html(leagues);
}