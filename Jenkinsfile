pipeline {
    agent any
    stages {
        stage ('Checkout') {
            steps {
                checkout scm
            }
        }

        stage ('Build') {
            steps {
                bat "\"C:/Program Files/dotnet/dotnet.exe\" restore \"${workspace}/TestSearchRepoQueries/TestSearchRepoQueries.sln\""
                bat "\"C:/Program Files/dotnet/dotnet.exe\" build \"${workspace}/TestSearchRepoQueries/TestSearchRepoQueries.sln\""
            }
        }

        stage ('UnitTests') {
            steps {
                bat returnStatus: true, script: "\"C:/Program Files/dotnet/dotnet.exe\" test \"${workspace}/TestSearchRepoQueries/TestSearchRepoQueries.sln\" --filter \"TestCategory=category\" --logger \"nunit;LogFileName=unit_tests.xml\" --no-build"
                script {
                    nunit testResultsPattern: 'TestSearchRepoQueries/TestSearchRepoQueries/TestResults/unit_tests.xml', failedTestsFailBuild: true
                }
            }
        }
    }
}