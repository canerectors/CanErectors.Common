//def repo

node{
    repo = "${env.PIPELINE_SCRIPTS_REPO}"
	folder = "${env.PIPELINE_SCRIPTS_FOLDER}"
	credentialsId = "${env.FILE_LOADER_CREDENTIALS_ID}"
}

def nuget = fileLoader.fromGit(folder + '/nugetpublish', 
	repo, 'master', credentialsId, '')
    
nuget.publish()