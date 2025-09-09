# how-to-display-empty-view-when-.net-maui-aiassistview-has-no-data

This demo explains about how to display and customize the empty view content when no request or response has been added.

## Sample

```xaml

    <syncfusion:SfAIAssistView x:Name="sfAIAssistView" 
                               AssistItems="{Binding AssistItems}"
                               RequestCommand="{Binding AssistViewRequestCommand}"
                               StopRespondingCommand="{Binding StopRespondingCommand}"
                               EmptyView="No Items">
    <syncfusion:SfAIAssistView.EmptyViewTemplate>
        <DataTemplate>
            <Grid RowDefinitions="45,30" RowSpacing="10" HorizontalOptions="Center" VerticalOptions="Center">
                <Border Background="#6C4EC2" Stroke="#CAC4D0" HorizontalOptions="Center" >
                    <Border.StrokeShape>
                        <RoundRectangle CornerRadius="12"/>
                    </Border.StrokeShape>
                    <Label Text="&#xe7e1;" 
                           FontSize="24" 
                           HorizontalTextAlignment="Center" 
                           VerticalTextAlignment="Center" 
                           FontFamily="MauiSampleFontIcon" 
                           TextColor="White" 
                           HeightRequest="45" 
                           WidthRequest="45" 
                           HorizontalOptions="Center" />
                </Border>
                <Label Text="Hi, How can I help you!" 
                       HorizontalOptions="Center" 
                       Grid.Row="1" 
                       FontFamily="Roboto-Regular" 
                       FontSize="20"/>
            </Grid>
        </DataTemplate>
    </syncfusion:SfAIAssistView.EmptyViewTemplate>

```

## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.
