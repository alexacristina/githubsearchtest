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
                bat returnStatus: true, script: "\"C:/Program Files/dotnet/dotnet.exe\" test \"${workspace}/TestSearchRepoQueries/TestSearchRepoQueries.sln\" --logger \"trx;LogFileName=unit_tests.xml\" --no-build"
                script {
                    [$class: "nunit", testResultsPattern: "**/unit_tests.xml", failIfNoResults: true, failedTestsFailBuild: true]
                }
            }
        }
    }
}