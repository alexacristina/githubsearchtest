## Steps to Create Multibranch Pipeline

Follow these steps:

1. **Log in to Jenkins**: Open your web browser and navigate to your Jenkins instance.

2. **Create a New Item**:
   - Click on "New Item" on the Jenkins homepage.
   - Enter a name for your pipeline (e.g., "MyMultibranchPipeline").
   - Select "Multibranch Pipeline" and click "OK".

3. **Configure Branch Sources**:
   - In the "Branch Sources" section, click on "Add Source" and select "Git".
   - Enter the Repository URL: `https://github.com/alexacristina/githubsearchtest.git`
   - Leave other settings as default or configure as needed.

4. **Save and Build**: 
   - Click on "Save" to create the Multibranch Pipeline.
   - Jenkins will automatically scan the repository and create sub-projects for each branch it finds.

5. **Trigger Builds to run Unit tests**:
   - Follow the guidelines of *Triggering Builds for a Branch Manually in Jenkins* written below

## Triggering Builds for a Branch Manually in Jenkins

To trigger builds for a branch manually in Jenkins, follow these steps:

1. **Navigate to the Multibranch Pipeline Project**:
   - Locate the Multibranch Pipeline project for which you want to trigger a build.
   - Click on the project name to enter its dashboard.

2. **Select the Branch**:
   - From the list of branches displayed on the dashboard, click on the branch for which you want to trigger the build. 

3. **Initiate the Build**:
   - Look for the "Build Now" or "Run" button. It may be located near the branch name or within the branch details page.
   - Click on the "Build Now" or "Run" button to manually trigger the build for the selected branch.
   - Jenkins will automatically trigger build for the selected branch based on the Jenkinsfile present in the repository.

4. **Monitor the Build Progress**:
   - Once the build is triggered, Jenkins will start executing the pipeline for the selected branch.
   - You can monitor the build progress and view the console output to track the execution steps.

By following these steps, you can manually trigger builds for specific branches in a Multibranch Pipeline project in Jenkins.

## Additional Configuration

You may need to configure additional settings based on your specific requirements, such as:
- Setting up build triggers.
- Defining build environment variables.
- Configuring post-build actions.
- Adding credentials for accessing the Git repository.

Refer to Jenkins documentation for detailed configuration options.

## Troubleshooting

If you encounter any issues during setup or execution of the pipeline, refer to Jenkins logs for error messages and consult Jenkins documentation for troubleshooting guidance.
