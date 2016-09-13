copy 'src\Invio.Xunit\project.json' 'src\Invio.Xunit\project.json.bak'
$project = Get-Content 'src\Invio.Xunit\project.json.bak' -raw | ConvertFrom-Json
$project.buildOptions.debugType = "full"
$project | ConvertTo-Json  | set-content 'src\Invio.Xunit\project.json'
